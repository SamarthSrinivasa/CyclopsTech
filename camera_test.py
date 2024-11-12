import cv2

#ap = cv2.VideoCapture(0)
camera1 = cv2.VideoCapture(1, cv2.CAP_DSHOW)
camera2 = cv2.VideoCapture(2, cv2.CAP_DSHOW)

if not camera1.isOpened() or not camera2.isOpened():
    print("Cannot open camera")
    exit()  

fourcc = cv2.VideoWriter_fourcc(*'XVID')
out1 = cv2.VideoWriter('output1.avi', fourcc, 20.0, (640, 480))
out2 = cv2.VideoWriter('output2.avi', fourcc, 20.0, (640, 480))

while True:
    ret1, frame1 = camera1.read()
    ret2, frame2 = camera2.read()

    if ret1:
        out1.write(frame1)
        cv2.imshow('Camera 1', frame1)

    if ret2:
        out2.write(frame2)
        cv2.imshow('Camera 2', frame2)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

camera1.release()
camera2.release()
out1.release()
out2.release()
cv2.destroyAllWindows()


