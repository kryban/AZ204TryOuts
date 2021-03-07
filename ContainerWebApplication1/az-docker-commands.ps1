
foo
az login
az group create --name live-bandik-we --location westeurope
az acr create --resource-group live-bandik-we --name bansacr --sku Standard

az acr login --name bansacr
$acrLoginServer = (az acr show --name bansacr --query loginServer)
write-host($acrLoginServer)

#build image, tag it and push it to acr
docker build --progress plan -t bansimage001:v001 D:\Leren\AZ-204\docker\ContainerApp\ContainerWebApplication1
docker image ls
docker tag bansimage001:v001 $acrLoginServer/bansimage001:v001az
docker push $acrLoginServer/bansimage001:v001az

#create service principal so ACI may access ACR to pull images for containers
$acrRegistryId = (az acr show --name bansacr --query id)
write-host($acrRegistryId)

# the password can only be queried during sp creation (N6wD805PNGIfts-vGX2CPAHf.vg_Mg75Et)
$spPassword2 = (az ad sp create-for-rbac --name http://banssp-acr-pull --scopes $acrRegistryId --role acrpull --query password --output tsv)
write-host($spPassword2)

$spId = (az ad sp show --id http://banssp-acr-pull --query appId)
write-host($spId)


# create container
az container create -g live-bandik-we --name banscontainer001-dns --dns-name-label bansContainer001 --ports 80 --image $acrLoginServer/bansimage001:v001az --registry-login-server $acrLoginServer --registry-username $spId --registry-password $spPassword2

# create another container
az container create -g live-bandik-we --name banscontainer002-dns --dns-name-label bansContainer002 --ports 80 --image $acrLoginServer/bansimage001:v001az --registry-login-server $acrLoginServer --registry-username $spId --registry-password $spPassword2


az container logs -g live-bandik-we --name banscontainer002-dns

# clean up containers
az container delete -g live-bandik-we --name banscontainer001-dns --yes
az container delete -g live-bandik-we --name banscontainer002-dns --yes



