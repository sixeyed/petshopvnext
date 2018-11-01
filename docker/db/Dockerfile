# escape=`
FROM microsoft/mssql-server-windows-express:2016-sp1

ENV ACCEPT_EULA="Y" `
    DATA_PATH="C:\data" `
    sa_password="DockerCon!!!"

VOLUME ${DATA_PATH}

COPY ./database/DatabaseScripts/ .
RUN ./InstallDatabases.cmd