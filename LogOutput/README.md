# Log Output

## 1.1
Run kubectl create deployment logoutput --image=alago0/logoutput 

## 1.3
Run kubectl apply -f manifests/deployment.yaml

## 1.7
Run: kubectl apply -f manifests </br>
Access: 127.0.0.1:8081

## 1.10
Run: kubectl apply -f manifests </br>
Access: 127.0.0.1:8081

## 1.11
Create dir on agent 0: docker exec k3d-k3s-default-agent-0 mkdir -p /tmp/kube </br>
</br>
In root folder run: </br>
kubectl apply -f volume-manifests </br>
kubectl apply -f PingPong/manifests </br>
kubectl apply -f LogOutput/manifests</br>
</br>
Access localhost:8081/pingpong to write pongs</br>
Access localhost:8081 to read logoutput and ping/pongs

## 2.1
In root folder run: </br>
kubectl apply -f PingPong/manifests </br>
kubectl apply -f LogOutput/manifests </br>
</br>
Access localhost:8081/pingpong to write pongs</br>
Access localhost:8081 to read logoutput and ping/pongs

## 2.3
Create namespace exercises: kubectl create namespace exercises </br>
Namespaces are specified in yaml files </br>
Run in root: kubectl apply -f volume-manifests/pingpongvolume.yaml </br>
Run in root: kubectl apply -f volume-manifests/pingpongvolumeclaim.yaml </br>
Run in root: kubectl apply -f PingPong/manifests </br>
Run in root: kubectl apply -f LogOutput/manifests</br>
Access localhost:8081/pingpong to write pongs</br>
Access localhost:8081 to read logoutput and ping/pongs
