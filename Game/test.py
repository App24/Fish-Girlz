from PIL import Image

im = Image.open("icon32x32.png")

width, height = im.size
text="AddColor(ref pixels, new Color[]{"
i=0
for x in range(width):
    for y in range(height):
        r,g,b,a = im.getpixel((x,y))
        text+="new Color("+str(r)+", "+str(g)+", "+str(b)+", "+str(a)+"), "
        i+=1
        if i % 20==0:
            i=0
            text+="\n"

text+="});"
with open("code.txt", "w") as f:
    f.write(text)