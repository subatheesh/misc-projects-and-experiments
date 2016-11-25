import os
import collections
#from ordereddict import OrderedDict
import pickle
from operator import itemgetter
 
# get list of files in curr dir
curList = os.listdir(".")

word2FileMap = collections.defaultdict(dict)

# load pickle file of HASH MAP if any
try:
    with open("Index.pkl", "rb") as input_file:
        word2FileMap = pickle.load(input_file)
except:
    print("Creating the new Index file! (NO old file found)")
    
for fname in curList:
    # Neglect .bin files and Script files or INdex files
    if ".bin" not in fname and ".py" not in fname and ".pkl" not in fname:
        curFP = open(fname,"r")
        curFLines = curFP.readlines()
        for line in curFLines:
            for w in line.split():
                try:
                    word2FileMap[w][fname] += 1
                except KeyError as e:
                    word2FileMap[w][fname] = 1

# Sorting done in query.py
# sorting based on word freq
#for k in word2FileMap.keys():
#    # word2FileMap[k] = OrderedDict(sorted(word2FileMap[k] , key = itemgetter(1), reverse = True))
#    word2FileMap[k] = sorted(word2FileMap[k] , key = itemgetter(1), reverse = True)           

print(word2FileMap)
# saving Index file as a HASH MAP (High Performance Data Struct in Python)         
with open("Index.pkl", "wb") as output_file:
    pickle.dump(word2FileMap, output_file)
