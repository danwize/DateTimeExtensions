FROM mcr.microsoft.com/vscode/devcontainers/dotnet:5.0

RUN useradd -m -s $(which bash) developer

#RUN apt-get update && apt-get install git
RUN chown developer:developer /