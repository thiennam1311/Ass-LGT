import pygame
import sys
import random
import math
from pygame.locals import *

# Define window size
WINDOWSWIDTH = 800
WINDOWSHEIGHT = 480

# Define color
WHITE = (255, 255, 255)
GRAY = (185, 185, 185)
BLACK = (0,   0,   0)
RED = (255,   0,   0)
LIGHTRED = (175,  20,  20)
GREEN = (0, 155,   0)
LIGHTGREEN = (20, 175,  20)
BLUE = (0,   0, 155)
LIGHTBLUE = (20,  20, 175)
YELLOW = (155, 155,   0)
LIGHTYELLOW = (175, 175,  20)




class mouse:
    def __init__(self):
        self.img = []
        self.numberImg = 17
        self.index = 0
        for self.index in range(0,self.numberImg):
            self.img.append(pygame.image.load("image/up"+str(self.index)+".png"))
        self.index = 0
    def update(self,mouseClick):
        if self.index == self.numberImg - 1:
            self.index = 0
        else:
            self.index+=1
    def render(self,screen,x,y):
        screen.blit(self.img[self.index],(x,y))

class hammer:
    def __init__(self,x,y,click):
        self.x = x
        self.y = y
        self.click = click
        if click:
            self.img = pygame.image.load("image/hammer2.png")
        else:
            self.img = pygame.image.load("image/hammer1.png")
    def render(self,screen):
        screen.blit(self.img,(self.x,self.y))

class punc:
    def __init__(self):
        self.img = []
        self.numberImg = 21
        self.index = 0
        for self.index in range(0,self.numberImg):
            self.img.append(pygame.image.load("image/punch"+str(self.index)+".png"))
        self.index = 0
    def update(self):
        if self.index == self.numberImg - 1:
            self.index = 0
        else:
            self.index+=1
    def render(self,screen,x,y):
        screen.blit(self.img[self.index],(x,y))
def main():
    pygame.init()
    # Bien toan cuc
    global isMouseClick,score,miss,GameLoop,clock,speed,timer,click,punch,screen,playSound
    # Khai bao gia tri
    isMouseClick = False
    GameLoop = True
    count=0
    change=0;
    speed=40
    timer=60
    click=False
    punch=False
    score=0
    miss=0
    countImgLoad=0
    playSound = True
    # Vi tri dat lo
    position = [[200,100],[500,100],[350,200],[200,300],[500,300]]
    up = random.randint(0,4)
    mouses = mouse()
    pun = punc()
     # Thiet lap cua so game
    screen = pygame.display.set_mode((WINDOWSWIDTH,WINDOWSHEIGHT))
    # Ten cua so game
    pygame.display.set_caption('Cyclone Team')
     # Am thanh khi click chuot
    soundclick = pygame.mixer.Sound("sound/mouseClick.wav")
    # Nhac nen, chay nhac nen
    soundBackground = pygame.mixer.music.load("sound/background.mp3")
    pygame.mixer.music.play(-1)
    # Hinh nen
    imageBackground = pygame.image.load('image/background.png')
    # Hinh anh hole
    image = pygame.image.load('image/empty.png')
    # Lay thoi gian
    clock = pygame.time.Clock()
     # Show background
    screen.blit(imageBackground,(0,0))
    pygame.display.update()
    # Vong lap game
    while GameLoop:
        # Su kien phim, chuot
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                    pygame.quit()
                    exit(0)

            if event.type == pygame.MOUSEBUTTONDOWN:
                mx2,my2 = event.pos
                #Hole tren trai
                if my2 >= 160 and my2 <= 210 and up == 0 and mx2 >= 250 and mx2 <= 300:
                       punch = True
                       score+=1
                #Hole tren phai
                elif my2 >= 160 and my2 <= 210 and up == 1 and mx2 >= 550 and mx2 <= 600:
                        punch = True
                        score+=1
                #Hole giua
                elif my2 >= 270 and my2 <= 320 and up == 2 and mx2 >= 400 and mx2 <= 450:
                        punch = True
                        score+=1
                #Hole duoi trai
                elif my2 >= 400 and my2 <= 470 and up == 3 and mx2 >= 250 and mx2 <= 300:
                        punch = True
                        score+=1
                #Hole duoi phai
                elif my2 >= 350 and my2 <= 400 and up == 4 and mx2 >= 550 and mx2 <= 600:
                        punch = True
                        score+=1

                click = True
            #Click tha chuot
            if event.type == pygame.MOUSEBUTTONUP:                
                click = False
                playSound = True
            # Lay vi tri chuot
            if event.type == pygame.MOUSEMOTION:
                mx,my = event.pos

        #draw background and display score:
        screen.blit(imageBackground,(0,0))
        seconds = clock.tick() / 1000.0
        timer-=seconds*2
        displayTimer = math.trunc(timer)
        if displayTimer == 0:
            GameLoop = False
            showScore()

        # Define font
        font = pygame.font.Font("font/calibri.ttf", 25)
        textScore = font.render("Score: " + str(score), True, LIGHTRED)
        screen.blit(textScore, [0, 170])
        textMiss = font.render("Miss: " + str(miss), True, LIGHTGREEN)
        screen.blit(textMiss, [0, 220])
        textTimer = font.render("Time: " + str(displayTimer)+"s", True, LIGHTBLUE)
        screen.blit(textTimer, [0, 270])

        #draw holes:

        for y in range(0,len(position)):
            if y != up:
                screen.blit(image,(position[y][0],position[y][1]))

        if punch:
            pun.render(screen,position[up][0],position[up][1])
            pun.update()
            change = 0
            count+=1
            
        else:
            mouses.render(screen,position[up][0],position[up][1])
            mouses.update(punch)
            countImgLoad+=1
        # dem so lan miss
        if countImgLoad == 17 and not punch:
            countImgLoad = 0
            miss+=1
        # Nhac khi click
        if click:         
            if playSound:                
                soundclick.play()
                playSound = False
            hammer(mx - 30,my - 80,click).render(screen)
            
        #Load hinh neu khong danh ma di chuyen chuot
        else:
            hammer(mx - 30,my - 80,click).render(screen)

        if punch and count == 21:
            punch = False
            change = -1
            count = 0
            mouses.__init__()
            up = random.randint(0,4)

        if change == 20 and punch == False:
            change = 0
            up = random.randint(0,4)


        change+=1

        clock.tick(speed)
        pygame.display.update()
def showScore():
    loop = True
    while loop:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                    pygame.quit()
                    exit(0)

        # Define font
        font = pygame.font.Font("font/calibri.ttf", 50)
        font.set_bold(1)
        textHit = font.render("Score: " + str(score), True, LIGHTRED)
        screen.blit(textHit, [350, 300])
        textMiss = font.render("Miss : " + str(miss), True, LIGHTBLUE)
        screen.blit(textMiss, [350, 350])        
        pygame.display.update()


if __name__ == '__main__':
    main()


