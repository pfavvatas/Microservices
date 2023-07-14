**Install the Ingress-Nginx Controller**

1. `kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.8.1/deploy/static/provider/aws/deploy.yaml`
2. `kubectl get namespace` check the ingress-nginx
3. `kubectl get pods --namespace=ingress-nginx` check pods
4. delete not running containers
5. `kubectl get services --namespace=ingress-nginx` check services
6. set `127.0.0.1 acme.com` to `C:\Windows\System32\drivers\etc\hosts`
7. `kubectl apply -f ingress-srv.yaml`

**Storage**

1. `kubectl get storageclass`
2. `kubectl apply -f local-pvc.yaml`
3. `kubectl get pvc`
4. Create MySQL administrator password `kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55w0rd!"` for `mssql`
5. `kubectl apply -f mssql-plat-depl.yaml`
6. Check services `kubectl get services` mssql-clusterip-srv and mssql-loadbalancer
7. Check pods `kubectl get pods` mssql-depl-XXXXX-XXX if it is ready
8. Open SQL Server `SQL Server Management Studio (SSMS)`
   1. Server type: `Database Engine`
   2. Server name: `localhost,1433`
   3. Authentication: `SQL Server Authentication`
   4. Login: `sa`
   5. Password: `pa55w0rd!`
