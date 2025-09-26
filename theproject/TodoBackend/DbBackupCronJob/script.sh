set -e
URL="postgresql://${PG_USER}:${PG_PASS}@${PG_HOST}/${PG_DB}"
#pg_dump -v "$URL" > /job/backup.sql
gsutil cp /job/script.sh gs://alex-devopswithkubernetes-bucket/
