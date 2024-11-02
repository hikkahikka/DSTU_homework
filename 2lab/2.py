s = input("Input text: ").split()
vowels_eng="eyuioa"
vowels_rus="уеыаоэяиюё"
counter = 0
for i in s:
    if ((i[0] in vowels_eng) or (i[0] in vowels_rus)):
        counter +=1
        print(i)
print(counter)
