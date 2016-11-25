import os
import collections
#from ordereddict import OrderedDict
import pickle
from operator import itemgetter
 
# get list of files in curr dir
curList = os.listdir(".")

word2FileMap = collections.defaultdict(dict)

# to find all co occuring words to form a phrase
def find_ngrams(listI,n):
    grams = []
    for i in zip(*[listI[j:] for j in range(n)]):
            grams.append(" ".join(i))
    return grams


# load pickle file of HASH MAP if any
try:
    with open("IndexP.pkl", "rb") as input_file:
        word2FileMap = pickle.load(input_file)
except:
    print("Creating the new Index file! (NO old file found)")
    
for fname in curList:
    # Neglect .bin files and Script files or INdex files
    if ".bin" not in fname and ".py" not in fname and ".pkl" not in fname:
        curFP = open(fname,"r")
        curFLines = curFP.readlines()
        wordsOrdered = []
        for line in curFLines:
            wordsOrdered.extend([w1 for w1 in line.split()])
        #print(wordsOrdered)
        phraseOrdered = []
        for i in range(0,5): 
            phraseOrdered.extend(find_ngrams(wordsOrdered, i))
        #print(phraseOrdered)
        for phrase in phraseOrdered:
            #print(phrase)
            try:
                word2FileMap[phrase][fname] += 1
            except KeyError as e:
                word2FileMap[phrase][fname] = 1

# Sorting done in query.py (SKIPPED here)
# sorting based on word freq
#for k in word2FileMap.keys():
#    # word2FileMap[k] = OrderedDict(sorted(word2FileMap[k] , key = itemgetter(1), reverse = True))
#    word2FileMap[k] = sorted(word2FileMap[k] , key = itemgetter(1), reverse = True)           

print(word2FileMap)
# saving Index file as a HASH MAP (High Performance Data Struct in Python)         
with open("IndexP.pkl", "wb") as output_file:
    pickle.dump(word2FileMap, output_file)
