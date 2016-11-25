import sys
import pickle
import collections
from operator import itemgetter

# load pickle file of HASH MAP if any
word2FileMap = ""
with open("IndexP.pkl", "rb") as input_file:
    word2FileMap = pickle.load(input_file)

for QueryPhrase in sys.argv[1:]:
    try:
        print("Searching for '"+QueryPhrase+"' ...")
        if QueryPhrase in word2FileMap:
            print("Found In: ")
        else:
            print("Not Found !!")
        for fileEntry in sorted(word2FileMap[QueryPhrase] , key = itemgetter(1), reverse = True):
            print(fileEntry)
        print()
    except KeyError as e:
        print("Not Found !!")
