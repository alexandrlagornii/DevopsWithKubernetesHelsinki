FROM google/cloud-sdk:stable
WORKDIR /job
COPY ./sa.json /sa/sa.json
COPY ./script.sh .
RUN apt-get update && \
	apt-get install -y curl ca-certificates && \
	install -d /usr/share/postgresql-common/pgdg && \
	curl -o /usr/share/postgresql-common/pgdg/apt.postgresql.org.asc --fail https://www.postgresql.org/media/keys/ACCC4CF8.asc && \
	. /etc/os-release && \
	sh -c "echo 'deb [signed-by=/usr/share/postgresql-common/pgdg/apt.postgresql.org.asc] https://apt.postgresql.org/pub/repos/apt $VERSION_CODENAME-pgdg main' > /etc/apt/sources.list.d/pgdg.list" && \
	apt-get update && \
	apt-get install -y postgresql-client-17 && \
    rm -rf /var/lib/apt/lists/* && \
	gcloud auth login --cred-file="/sa/sa.json" && \
    rm -rf /sa
CMD ["bash", "./script.sh"]
