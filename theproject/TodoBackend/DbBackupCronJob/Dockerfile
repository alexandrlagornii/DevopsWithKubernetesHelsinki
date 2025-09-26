FROM google/cloud-sdk:stable
WORKDIR /job
COPY ./sa.json /sa/sa.json
COPY ./script.sh .
RUN apt-get update && \
    apt-get install -y curl postgresql-client && \
    rm -rf /var/lib/apt/lists/* && \
	  gcloud auth login --cred-file="/sa/sa.json" && \
    rm -rf /sa
CMD ["bash", "./script.sh"]
