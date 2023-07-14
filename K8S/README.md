**Install the Ingress-Nginx Controller**

1. `kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.8.1/deploy/static/provider/aws/deploy.yaml`
2. `kubectl get namespace` check the ingress-nginx
3. `kubectl get pods --namespace=ingress-nginx` check pods
4. delete not running containers
5. `kubectl get services --namespace=ingress-nginx` check services
6. set `127.0.0.1 acme.com` to `C:\Windows\System32\drivers\etc\hosts`
7. `kubectl apply -f ingress-srv.yaml`
