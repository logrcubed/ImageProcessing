#import the required module.
import RPi.GPIO as GPIO
import os
import time
import picamera

# Set the mode of numbering the pins.
GPIO.setmode(GPIO.BCM)

#set pin 4
GPIO.setup(27, GPIO.IN)

#set GPIO pin as output
GPIO.setup(17, GPIO.OUT)

# Initialise GPIO 3 to high (true) so that it acts as high input to other pins
GPIO.output(17, GPIO.HIGH)

while 1:
	value = GPIO.input(27)
	if value:
		print "inside if loop"
	  	#os.system('python cameratest.py')
		#os.system('sh email.sh')
		with picamera.PiCamera() as camera:
		     camera.start_preview()
		     time.sleep(2)
		     camera.capture('Trilok_image_pi.jpg')
		     camera.stop_preview()
		camera.close()
		os.system('mv /home/pi/Trilok_image_pi.jpg /home/pi/gpioproject/image.jpg')
		os.system('mono "/opt/windowapp.exe"')
	      	print "image taken and mail sent"
		
print "outside the loop"
