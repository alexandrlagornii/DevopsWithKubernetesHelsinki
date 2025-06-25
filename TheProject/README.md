# The Project

## 1.2
Run kubectl create deployment theproject --image=alago0/theproject

## 1.4
Run kubectl apply -f manifests/deployment.yaml

## 1.5
Start (see 1.2 or 1.4) and run:
kubctl get po - to get pod name
kubectl port-foward <pod> <port-you-want>:80 - 80 is default port for asp net apps
