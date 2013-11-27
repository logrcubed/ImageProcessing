import time
import picamera

with picamera.PiCamera() as camera:
     camera.start_preview()
     time.sleep(2)
     camera.capture('Trilok_image_pi.jpg')
     camera.stop_preview()
camera.close()
