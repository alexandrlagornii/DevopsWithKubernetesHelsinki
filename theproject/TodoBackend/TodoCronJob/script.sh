set -e

page=$(curl -sL -w "%{url_effective}" -o /dev/null https://en.wikipedia.org/wiki/Special:Random)
todo="Read $page"
psql "postgresql://$PG_USER:$PG_PASS@$PG_HOST/$PG_DB" -c "INSERT INTO todos (name) values ('$todo');"