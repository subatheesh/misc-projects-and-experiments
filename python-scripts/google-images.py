import urllib.request
import re
import selenium
from selenium import webdriver

q=input("Enter the image query: ")
q=q.split()
query='+'.join(q)
ur="http://images.google.com/search?q="+str(query)+"&biw=1366&bih=665&tbm=isch&source=lnt&tbs=isz:l&sa=X&ei=-h-WUe-3IYTsrAfbnoHoAw&ved=0CBcQpwUoAQ.html"

browser = webdriver.Firefox()
browser.get(ur)
html_source = browser.page_source
browser.close()

print(html_source)
f=open("imgtemp.html","w")
f.write(html_source)

#with urllib.request.urlopen(ur) as url:
            #response=url.read().decode("utf-8")
imgurl=re.findall(r';imgurl=(.*).',html_source)
print(imgurl)



