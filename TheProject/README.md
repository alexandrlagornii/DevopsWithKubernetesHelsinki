# The Project

## 1.2
Run kubectl create deployment theproject --image=alago0/theproject

## 1.4
Run kubectl apply -f manifests/deployment.yaml

## 1.5
Start (see 1.2 or 1.4) and run: <br />
kubctl get po - to get pod name <br />
kubectl port-foward `<pod>` `<port-you-want>`:80 - 80 is default port for asp net apps (Can also change ENV variable PORT to change it)

## 1.6
k3d cluster create --port 8082:30080@agent:0 -p 8081:80@loadbalancer --agents 2 <br />
kubectl apply -f manifests/service.yaml <br />
kubectl apply -f manifests/deployment.yaml <br />
Access using localhost:8082

## 1.7
Run: kubectl apply -f manifests <br />
Access: localhost:8081
