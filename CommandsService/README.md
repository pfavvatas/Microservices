commands:

**Docker:**

1. `docker build -t pfavvatas/commandsservice .`
2. `docker run -p 8080:80 --name commandsservice-container -d pfavvatas/commandsservice`
3. `docker ps`
   CONTAINER ID IMAGE COMMAND CREATED STATUS PORTS NAMES

   93c11c33c0ae pfavvatas/commandsservice "dotnet PlatformServ…" Less than a second ago Up 30 seconds 0.0.0.0:8080->80/tcp dreamy_euclid

4. `docker stop "CONTAINER ID"` example `docker stop 93c11c33c0ae`
5. `docker start "CONTAINER ID"` example `docker start 93c11c33c0ae`
6. `docker push pfavvatas/commandsservice`

**Kubernetes:**
Kubernetes is running ? `kubectl version`

1. Apply .yaml file `kubectl apply -f commands-depl.yaml`
2. `kubectl get deployments`
3. `kubectl get pods`
4. delete deployment `kubectl delete deployment commands-depl`
5. Access to Service: Need to create a Node port mapping `K8S\commands-np-srv.yaml`
   1. `kubectl apply -f commands-np-srv.yaml`
   2. `kubectl get services` find the port
   <!-- 3. test service `http://localhost:32271/api/platforms` -->
