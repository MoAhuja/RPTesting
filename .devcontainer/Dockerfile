FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy

WORKDIR /tmp

# Install extra packages
RUN apt-get update -y \
  && apt-get install -y openssh-client nano jq sudo curl


# Add vscode user
ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID
RUN groupadd --gid $USER_GID $USERNAME \
  && useradd --uid $USER_UID --gid $USER_GID -m $USERNAME -s /bin/bash \
  && echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME \
  && chmod 0440 /etc/sudoers.d/$USERNAME



USER $USERNAME

# Install porter


# Install VIM. Used for git difftool
# TODO Remove becuase having issue building Dev Container
# RUN apt-get update -y && apt install vim


