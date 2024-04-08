# What
Here's the technical requirement:

Envoyé : mercredi 3 avril 2024 17:47
Objet : Entretien tech dév. .net sén. hier 15h
 
Bonjour Messieurs,

    Merci pour vos disponibilité, écoute bienveillante, questions et conseils hier.

Par l'heure ensemble hier vous améliorez ma veille technique toute cette semaine.

Dès que possible, 
      avec comme objectif paresseux lundi matin, 
            vous avez facilité la préparation d'un kata dans le domaine GED à minima sur les thèmes:
SignalR
OData
et surtout un microservice utilisant
LInQ
del
DI
RabbitMQ
SQL Serv.
Docker

Bonne fin de semaine,
Eric
dév. C#.net / intégrateur web React

# How
https://dotnet.microsoft.com/en-us/learn/aspnet/microservice-tutorial/intro

dotnet publish --os linux --arch x64 /t:PublishContainer -c Release

or

fsutil file createnew Dockerfile 0

fsutil file createnew .dockerignore 0

docker build -t edmmicroservice

docker images

docker run -it --rm -p 3000:8080 --name edmmicroservicecontainer edmmicroservice

http://localhost:3000/findDocument

## trace
PS C:\Users\ericf\source\repos\Kata\Cegedim\EDMmicroService> docker build -t edmmicroservice .
[+] Building 138.8s (15/15) FINISHED                                                                                                                 docker:default 
 => [internal] load build definition from Dockerfile                                                                                                           1.3s 
 => => transferring dockerfile: 329B                                                                                                                           0.0s 
 => [internal] load metadata for mcr.microsoft.com/dotnet/aspnet:8.0                                                                                           3.1s 
 => [internal] load metadata for mcr.microsoft.com/dotnet/sdk:8.0                                                                                              3.2s 
 => [internal] load .dockerignore                                                                                                                              0.7s 
 => => transferring context: 68B                                                                                                                               0.0s 
 => [build 1/6] FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:249a78aa4ce22ab872d0dff0490a6389e7bc087d2c080c4ffc7569b49cf0e23b                                 84.5s 
 => => resolve mcr.microsoft.com/dotnet/sdk:8.0@sha256:249a78aa4ce22ab872d0dff0490a6389e7bc087d2c080c4ffc7569b49cf0e23b                                        1.0s 
 => => sha256:249a78aa4ce22ab872d0dff0490a6389e7bc087d2c080c4ffc7569b49cf0e23b 1.08kB / 1.08kB                                                                 0.0s 
 => => sha256:58e41940df879930c36ef23f37afe774831dfa15c67e3fc788808d9e1fb78494 2.22kB / 2.22kB                                                                 0.0s 
 => => sha256:7dd073a82957f9f311bf3631a8e706df9a7173d521994326386a2453def7550d 5.67kB / 5.67kB                                                                 0.0s 
 => => sha256:8a1e25ce7c4f75e372e9884f8f7b1bedcfe4a7a7d452eb4b0a1c7477c9a90345 29.12MB / 29.12MB                                                               7.3s 
 => => sha256:a903092de2dbe1032be255f6aa13a67ae083a3f265fd27233b508751272f445a 18.72MB / 18.72MB                                                               6.5s 
 => => sha256:a487f961ec6db6d8f7ddb5e2530d7ff34c3d9e00e1b7bac6c88a7b23ac1d3486 3.28kB / 3.28kB                                                                 2.4s 
 => => sha256:03ed6a6adf56f6f715105f0deee0751926934d40efc896e37dedb449be4fff73 32.23MB / 32.23MB                                                              12.2s 
 => => sha256:2900f7703f33131b08a583655daea49aaabb3922640bc9ec2f0bb47bbce0ae34 155B / 155B                                                                     7.7s 
 => => extracting sha256:8a1e25ce7c4f75e372e9884f8f7b1bedcfe4a7a7d452eb4b0a1c7477c9a90345                                                                      8.4s 
 => => sha256:1764125ee6d60582da2a93872439a6170cc1f7cda6a3e446cdc9d229a2ede0d2 11.02MB / 11.02MB                                                              10.1s 
 => => sha256:fd11341df62770f82c1a47525639eac60f39d0d9690dcdc18cd98bc17fd76b3e 30.69MB / 30.69MB                                                              13.4s 
 => => sha256:7a3936380e1e9a612f41403125971948e725b5de22a2ac34339b50a43ea8ff0f 187.59MB / 187.59MB                                                            31.4s
 => => sha256:c092aced01925a96404610e38c62c20b40d185f344f848d7dc20ef0240636db9 15.70MB / 15.70MB                                                              17.9s
 => => extracting sha256:a903092de2dbe1032be255f6aa13a67ae083a3f265fd27233b508751272f445a                                                                      2.5s
 => => extracting sha256:a487f961ec6db6d8f7ddb5e2530d7ff34c3d9e00e1b7bac6c88a7b23ac1d3486                                                                      0.0s
 => => extracting sha256:03ed6a6adf56f6f715105f0deee0751926934d40efc896e37dedb449be4fff73                                                                      3.6s
 => => extracting sha256:2900f7703f33131b08a583655daea49aaabb3922640bc9ec2f0bb47bbce0ae34                                                                      0.0s
 => => extracting sha256:1764125ee6d60582da2a93872439a6170cc1f7cda6a3e446cdc9d229a2ede0d2                                                                      1.1s
 => => extracting sha256:fd11341df62770f82c1a47525639eac60f39d0d9690dcdc18cd98bc17fd76b3e                                                                      4.1s
 => => extracting sha256:7a3936380e1e9a612f41403125971948e725b5de22a2ac34339b50a43ea8ff0f                                                                     17.5s
 => => extracting sha256:c092aced01925a96404610e38c62c20b40d185f344f848d7dc20ef0240636db9                                                                      3.4s 
 => [stage-1 1/3] FROM mcr.microsoft.com/dotnet/aspnet:8.0@sha256:60a3eb04639d0ab0e97c268ceeae6765314c30c2c062bc5ad0baafdde4f3eacc                            61.4s 
 => => resolve mcr.microsoft.com/dotnet/aspnet:8.0@sha256:60a3eb04639d0ab0e97c268ceeae6765314c30c2c062bc5ad0baafdde4f3eacc                                     1.3s 
 => => sha256:60a3eb04639d0ab0e97c268ceeae6765314c30c2c062bc5ad0baafdde4f3eacc 1.08kB / 1.08kB                                                                 0.0s 
 => => sha256:f0824b691f1c5c75855e078876e52bc88e93676e3e58a65642d09c1bf1f734f6 1.58kB / 1.58kB                                                                 0.0s 
 => => sha256:af3fdf211f2d6148c5dbc566dd604fedee9d9a0ad47ac5a0d3c630a5fed98e58 2.71kB / 2.71kB                                                                 0.0s 
 => => sha256:8a1e25ce7c4f75e372e9884f8f7b1bedcfe4a7a7d452eb4b0a1c7477c9a90345 29.12MB / 29.12MB                                                               7.1s 
 => => sha256:a903092de2dbe1032be255f6aa13a67ae083a3f265fd27233b508751272f445a 18.72MB / 18.72MB                                                               6.4s 
 => => sha256:a487f961ec6db6d8f7ddb5e2530d7ff34c3d9e00e1b7bac6c88a7b23ac1d3486 3.28kB / 3.28kB                                                                 2.2s 
 => => sha256:03ed6a6adf56f6f715105f0deee0751926934d40efc896e37dedb449be4fff73 32.23MB / 32.23MB                                                              12.0s 
 => => sha256:2900f7703f33131b08a583655daea49aaabb3922640bc9ec2f0bb47bbce0ae34 155B / 155B                                                                     7.6s 
 => => sha256:1764125ee6d60582da2a93872439a6170cc1f7cda6a3e446cdc9d229a2ede0d2 11.02MB / 11.02MB                                                              10.0s 
 => => extracting sha256:8a1e25ce7c4f75e372e9884f8f7b1bedcfe4a7a7d452eb4b0a1c7477c9a90345                                                                    123.1s 
 => => extracting sha256:a903092de2dbe1032be255f6aa13a67ae083a3f265fd27233b508751272f445a                                                                      2.5s 
 => => extracting sha256:03ed6a6adf56f6f715105f0deee0751926934d40efc896e37dedb449be4fff73                                                                    108.5s 
 => [internal] load build context                                                                                                                              7.3s 
 => => transferring context: 8.15MB                                                                                                                            5.2s 
 => [stage-1 2/3] WORKDIR /app                                                                                                                                16.8s 
 => [build 2/6] WORKDIR /src                                                                                                                                   1.5s 
 => [build 3/6] COPY EDMmicroService.csproj .                                                                                                                  1.9s 
 => [build 4/6] RUN dotnet restore                                                                                                                            12.1s 
 => [build 5/6] COPY . .                                                                                                                                       3.5s 
 => [build 6/6] RUN dotnet publish -c release -o /app                                                                                                         21.0s 
 => [stage-1 3/3] COPY --from=build /app .                                                                                                                     2.5s 
 => exporting to image                                                                                                                                         2.0s 
 => => exporting layers                                                                                                                                        1.8s 
 => => writing image sha256:d81ca8f5edf8f891ccd60dd34c1935a797c60c5e90c556e4c67d7c6f404bbbd4                                                                   0.1s 
 => => naming to docker.io/library/edmmicroservice                                                                                                             0.1s 

What's Next?
  View a summary of image vulnerabilities and recommendations → docker scout quickview
PS C:\Users\ericf\source\repos\Kata\Cegedim\EDMmicroService> docker images
REPOSITORY        TAG       IMAGE ID       CREATED         SIZE
edmmicroservice   latest    d81ca8f5edf8   2 minutes ago   229MB
PS C:\Users\ericf\source\repos\Kata\Cegedim\EDMmicroService> docker run -it --rm -p 3000:8080 --name edmmicroservicecontainer edmmicroservice
warn: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository[60]
      Storing keys in a directory '/root/.aspnet/DataProtection-Keys' that may not be persisted outside of the container. Protected data will be unavailable when container is destroyed. For more information go to https://aka.ms/aspnet/dataprotectionwarning
warn: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[35]
      No XML encryptor configured. Key {9ed5f31b-fa10-49e4-bd9e-d800e7aaf284} may be persisted to storage in unencrypted form.
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://[::]:8080
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.