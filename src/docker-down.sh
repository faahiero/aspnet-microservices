#!/bin/sh

docker-compose -f ./docker-compose.yml -f ./docker-compose.override.yml down
