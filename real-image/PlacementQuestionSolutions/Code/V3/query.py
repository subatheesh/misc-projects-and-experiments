import sys
import pickle
import collections
from operator import itemgetter

# load pickle file of HASH MAP if any
word2FileMap = ""
with open("Index.pkl", "rb") as input_file:
    word2FileMap = pickle.load(input_file)

for QueryWord in sys.argv[1:]:

    if "AND" in QueryWord:
        words = [w.strip() for w in QueryWord.split("AND")]
        fDict = collections.defaultdict(int)
        for tempWord in words:
            for fileEntry in sorted(word2FileMap[tempWord] , key = itemgetter(1), reverse = True):
                fDict[fileEntry] += 1
        f = 0
        for k in fDict.keys():
            if fDict[k] == len(words):
                if f == 0:
                    print("Found In:")
                    f = 1
                print(k)
        if f == 0:
            print("Not Found!!")
        print()
        
    else:
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
