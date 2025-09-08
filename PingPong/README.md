## 1.9
From root run: <br />
&nbsp;&nbsp;&nbsp;&nbsp;kubectl apply -f LogOutput/manifests <br />
&nbsp;&nbsp;&nbsp;&nbsp;kubectl apply -f PingPong/manifests <br />
Access: localhost:8081/pingpong


## 2.7
From root run: <br />
&nbsp;&nbsp;&nbsp;&nbsp;kubectl apply -f PingPong/manifests <br />
&nbsp;&nbsp;&nbsp;&nbsp;kubectl apply -f LogOutput/manifests <br />
To put ping into db: localhost:8081/pingpong <br />
To see pings and logs: localhost:8081


## 3.1
From root run: <br />
&nbsp;&nbsp;&nbsp;&nbsp;kubectl apply -f PingPong/manifests <br />
&nbsp;&nbsp;&nbsp;&nbsp;kubectl apply -f LogOutput/manifests <br />
To put ping into db: http://<pingpong-svc external ip>/pingpong <br />
To see pings and logs: http://<logoutput-svc external ip>/
