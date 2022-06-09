# Brief steps to build docker images

## Build CLI (PowerShell)

1. Setup variables

    ```powershell
    $dockeraccount='saars'  # switch with your docker account
    $image='cid'            # container id
    $version='0.0.2'       # the version number
    ```

1. Build docker image

    ```powershell
    docker build -t $image`:$version -f dockerfile .             #Build docker file
    ```

1. Test it locally

    ```powershell
    docker run -it $image`:$version
    ```

1. Publish the image

    ```powershell
    docker tag $image`:$version $dockeraccount/$image`:$version   #tag the image for publishing
    docker push $dockeraccount/$image`:$version
    docker tag $image`:$version $dockeraccount/$image`:latest   #tag the image for publishing
    docker push $dockeraccount/$image`:latest
    ```

## Build Worker Image

1. Setup variables

    ```powershell
    $dockeraccount='saars'  # switch with your docker account
    $image='cid-worker'            # container id
    $version='0.0.2'       # the version number
    ```

1. Build docker image

    ```powershell
    docker build -t $image`:$version -f dockerfile.worker .             #Build docker file
    ```

1. Test it locally

    ```powershell
    docker run -it $image`:$version
    ```

1. Publish the image

    ```powershell
    docker tag $image`:$version $dockeraccount/$image`:$version   #tag the image for publishing
    docker push $dockeraccount/$image`:$version
    docker tag $image`:$version $dockeraccount/$image`:latest   #tag the image for publishing
    docker push $dockeraccount/$image`:latest
    ```