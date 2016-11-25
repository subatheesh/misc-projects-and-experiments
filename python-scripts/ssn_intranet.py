import urllib.request
import re

alink=[]
blink=[]
adir=[]
bdir=[]

with urllib.request.urlopen("http://www.ssn.net/twiki/bin/view/CseIntranet/CseElearnFirstYear") as url:
            response=url.read().decode("utf-8")
            csea=re.findall(r'<a\shref="/twiki/bin/view/CseIntranet/CseA(.*)\sclass="twikiLink">(.*)</a>',response)
            csea.remove(csea[-1])
            cseb=re.findall(r'<a\shref="/twiki/bin/view/CseIntranet/CseB(.*)\sclass="twikiLink">(.*)</a>',response)
            cseb.remove(cseb[-1])


for item in csea:
    alink=alink+["http://www.ssn.net/twiki/bin/view/CseIntranet/CseA"+item[0]]
    adir=adir+[item[1]]
print (alink)
print (adir)
    
for item in cseb:
    blink=blink+["http://www.ssn.net/twiki/bin/view/CseIntranet/CseB"+item[0]]
    bdir=bdir+[item[1]]
print (blink)
print (bdir)

dlnk=[]

os.makedirs("CseA")

for link,dirs in alink,adir:
    with urllib.request.urlopen(link) as url:
            response=url.read().decode("utf-8")
            lnk=re.findall(r'<a\shref="(.*)"\starget="_top">',response)
            lnk.remove(lnk[-1])
            os.makedirs("CseA/"+str(dirs))




