# Aplicação PotentialCrud
Api JSON REST baseada em arquitetura DDD, desenvolvida e testada no VS Code.
Para UI/UX foi utilizado Swagger.
Banco de dados Mysql em container Docker, sendo necessário executar os seguintes comandos para baixar a imagem e criar o container:
  - docker pull mysql
  - docker run -e MYSQL_ROOT_PASSWORD=pass@2021 --name meu-mysql -d -p 3306:3306 mysql
