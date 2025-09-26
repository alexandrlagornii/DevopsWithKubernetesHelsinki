set -e
URL="postgresql://${PG_USER}:${PG_PASS}@${PG_HOST}/${PG_DB}"
DATE=$(date +%F)
pg_dump -v "$URL" > /job/backup-$DATE.sql
gsutil cp /job/backup.sql gs://alex-devopswithkubernetes-bucket/
