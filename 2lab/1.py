s = input("Input string: ")
counter = 0
for i in s:
    if (i.isalpha() and i.islower()):
        counter+=1

print(counter)
