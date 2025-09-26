FROM google/cloud-sdk:latest
WORKDIR /job
COPY ./sa.json /data/sa.json
COPY ./script.sh .
RUN gcloud auth login --cred-file="/data/sa.json" && \
    apt-get update && \
    apt-get install -y curl postgresql-client
CMD ["bash", "./script.sh"]
