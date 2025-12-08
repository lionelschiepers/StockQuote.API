docker build -t stockquote-api -f .\Dockerfile .
docker tag stockquote-api lionelschiepers/stockquote-api:latest
docker push lionelschiepers/stockquote-api:latest
