import selenium
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
import time
import re
import urllib.request
from selenium.webdriver import ActionChains
import subprocess
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

driver = webdriver.Firefox()
actionChains = ActionChains(driver)
driver.get("http://www.clipconverter.cc")
elem = driver.find_element_by_name("mediaurl")
elem.send_keys("www.youtube.com/watch?v=B62LVo87O-w",Keys.RETURN)
#selectopt = driver.find_elements_by_name("videores")
#print(selectopt[0])
time.sleep(10)
#actionChains.move_to_element(selectopt[2]).perform()
#selectopt[2].click()
#driver.find_element_by_type("submit").click()
elem.submit()
#try:
#    element = WebDriverWait(driver,10).until(EC.presence_of_element_located((By.ID, "myDynamicElement")))
#finally:
#    driver.quit()
time.sleep(20)
urll=driver.current_url
with urllib.request.urlopen(urll) as url:
            response=url.read().decode("utf-8")
            homeurl=re.findall(r'<a\sid=\"downloadbutton\"\shref=\"(.*)"\sclass=\"button\">',response)
            print (homeurl)
#driver.get("https://cyberghostvpn.com/proxy/?proxy=us.proxy.cyberghostvpn.com")
#ele = driver.find_element_by_name("u")
#ele.send_keys(homeurl,Keys.RETURN)
driver.close()
#time.sleep(10)
#urld=driver.current_url
#print(urld)

urld="https://losangeles-s01-i04-traffic.cyberghostvpn.com/go/browse.php?u="+str(homeurl[0])+"b=5&f=norefer"
subprocess.call("C:/Program Files (x86)/Internet Download Manager/IDMan.exe /n /d "+str(homeurl[0]))
