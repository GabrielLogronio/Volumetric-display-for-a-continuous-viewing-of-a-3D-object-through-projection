#!/bin/bash

SAFE_TO_RUN=0

DIR=./

if [ $SAFE_TO_RUN = 1 ]; then
    sed -i '3d' SuppressWarnings.sh
    sed -i '3d' DeSuppressWarnings.sh
    sed -i '3s/^/SAFE_TO_RUN=0\n/' SuppressWarnings.sh
    sed -i '3s/^/SAFE_TO_RUN=1\n/' DeSuppressWarnings.sh

    for i in $(find $DIR -type f -name "*.cs")
    do
        sed -i '1s/^/#pragma warning disable 0219\n#pragma warning disable 0168\n#pragma warning disable 0618\n#pragma warning disable 0649\n#pragma warning disable 0067\n#pragma warning disable 0414\n\n/' $i
    done
else
    echo "Not safe to run!"
fi