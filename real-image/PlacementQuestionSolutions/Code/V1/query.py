import sys
import pickle
from operator import itemgetter

# load pickle file of HASH MAP if any
word2FileMap = ""
with open("Index.pkl", "rb") as input_file:
    word2FileMap = pickle.load(input_file)

for QueryWord in sys.argv[1:]:
    try:
        print("Searching for "+QueryWord+" ...")
        if QueryWord in word2FileMap:
            print("Found In: ")
        else:
            print("Not Found !!")
        for fileEntry in sorted(word2FileMap[QueryWord] , key = itemgetter(1), reverse = True):
            print(fileEntry)
        print()
    except KeyError as e:
        print("Not Found !!")
