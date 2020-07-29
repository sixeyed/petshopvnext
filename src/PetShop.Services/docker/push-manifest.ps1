
$image='sixeyed/petshop-products-service:2007'

docker manifest create --amend $image `
 "$image-alpine-3.12" `
 "$image-nanoserver-1809"
 
docker manifest push --purge $image
