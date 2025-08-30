## 2.2
Run: docker exec k3d-k3s-default-agent-0 mkdir -p /tmp/randomimage <br />
In root run: kubectl apply -f volume-manifests/randomimagevolume.yaml <br />
In root run: kubectl apply -f volume-manifests/randomimagevolumeclaim.yaml <br />
In TheProject run: kubectl apply -f manifests <br />
In TodoBackend run: kubectl apply -f manifests <br />
Access using localhost:8081

## 2.8
Run: docker exec k3d-k3s-default-agent-0 mkdir -p /tmp/randomimage <br />
In root run: kubectl apply -f volume-manifests <br />
In TodoBackend run: kubectl apply -f manifests <br />
In TheProject run: kubectl apply -f manifests <br />
Access using localhost:8081