import os
DIR_LIST = [
    "C:/Users/10533/Desktop/SYMMETRIC_VISION/",
]

BASE = ""
# Find first path that is valid, fall back to relative path otherwise

for path in DIR_LIST:
    if os.path.exists(path):
        BASE = path
        print("Set Root path as "+ path)
        break