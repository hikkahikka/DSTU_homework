p = 12
r = 50
g = 9.81


for i in range (25, 70+5, 5):
    print ("  ",i, end = '\t')
print()

for v in range (25, 70+5, 5):
    f = p + ((p/g)*(v**2/r))
    print (round(f, 3), end = '\t')
