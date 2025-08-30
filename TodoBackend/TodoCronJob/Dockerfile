FROM ubuntu:22.04
WORKDIR /script
COPY ./script.sh .
RUN apt-get update && \
    apt-get install -y curl postgresql-client
CMD ["bash", "./script.sh"]