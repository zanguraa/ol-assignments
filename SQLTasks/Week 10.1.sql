CREATE TABLE Patients (
PatientId INT,
Name VARCHAR(255),
Age INT,
DateAdmitted DATE )

CREATE TABLE Doctors (
DoctorId INT NOT NULL,
Name VARCHAR(255) NOT NULL,
Specialization VARCHAR(255) NOT NULL
PRIMARY KEY (DoctorID)
)

CREATE TABLE Appointments (
AppointmentId INT PRIMARY KEY,
PatientId INT,
DoctorId INT,
Date Date,
Time Time )

ALTER TABLE Appointments
ADD CONSTRAINT FK_Patient_Appointment
FOREIGN KEY (PatientId)
REFERENCES Patients(PatientId);

ALTER TABLE Appointments
ADD CONSTRAINT FK_Doctor_Appointment
FOREIGN KEY (DoctorId)
REFERENCES Doctors(DoctorId);

SELECT * FROM Patients
WHERE DateAdmitted >= DATEADD(YEAR, -1, GETDATE())

SELECT D.DoctorId, D.Name, COUNT(A.AppointmentId) AS AppointmentCount, A.Date
FROM Doctors D
JOIN Appointments A ON D.DoctorId = A.DoctorId
GROUP BY D.DoctorId, D.Name, A.Date
HAVING COUNT(A.AppointmentId) > 5;