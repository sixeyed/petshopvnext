# escape=`
FROM microsoft/mssql-server-windows-express:2016-sp1

ENV ACCEPT_EULA="Y" `
    sa_password="DockerCon!!!"

COPY ./database/DatabaseScripts/ .
RUN ./InstallDatabases.cmd