#!/bin/bash

SAFE_TO_RUN=1

DIR=./

if [ $SAFE_TO_RUN = 1 ]; then
    sed -i '3d' SuppressWarnings.sh
    sed -i '3d' DeSuppressWarnings.sh
    sed -i '3s/^/SAFE_TO_RUN=1\n/' SuppressWarnings.sh
    sed -i '3s/^/SAFE_TO_RUN=0\n/' DeSuppressWarnings.sh

    for i in $(find $DIR -type f -name "*.cs")
    do
        sed -i '1,3d' $i
    done
else
    echo "Not safe to run!"
fi