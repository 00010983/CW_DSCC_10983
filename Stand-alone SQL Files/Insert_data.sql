-- Use DB database for tables after running Create_tables.sql
USE DB;
GO

-- Insert 30 records into the Customers table
INSERT INTO Customers (Name, DateOfBirth, Email, PhoneNumber, Address)
VALUES
    ('John Doe', '1990-01-15', 'john.doe@example.com', '123-456-7890', '123 Main St'),
    ('Jane Smith', '1985-03-20', 'jane.smith@example.com', '555-555-5555', '456 Elm St'),
    ('Robert Johnson', '1995-07-10', 'robert.j@example.com', '987-654-3210', '789 Oak Ave'),
    ('Sarah Wilson', '1980-09-05', 'sarah.wilson@example.com', '777-888-9999', '567 Pine Rd'),
    ('Michael Brown', '1992-12-02', 'michael.b@example.com', '111-222-3333', '101 Cedar Ln'),
    ('Emily Davis', '1998-04-30', 'emily.d@example.com', '444-555-6666', '222 Birch St'),
    ('David Lee', '1987-06-15', 'david.lee@example.com', '333-444-5555', '333 Elm St'),
    ('Lisa Moore', '1983-11-25', 'lisa.moore@example.com', '999-888-7777', '444 Oak Ave'),
    ('Matthew Taylor', '1982-08-14', 'matthew.t@example.com', '222-111-0000', '555 Pine Rd'),
    ('Olivia Martin', '1994-02-18', 'olivia.m@example.com', '666-777-8888', '666 Cedar Ln'),
    ('Daniel Hall', '1989-10-07', 'daniel.h@example.com', '777-888-9999', '777 Birch St'),
    ('Chloe White', '1991-05-12', 'chloe.w@example.com', '555-444-3333', '888 Elm St'),
    ('James Clark', '1997-03-29', 'james.c@example.com', '111-222-3333', '999 Oak Ave'),
    ('Ava Jackson', '1984-07-22', 'ava.j@example.com', '333-444-5555', '101 Pine Rd'),
    ('William Harris', '1993-09-17', 'william.h@example.com', '999-888-7777', '222 Cedar Ln'),
    ('Sophia Young', '1986-12-09', 'sophia.y@example.com', '222-111-0000', '333 Birch St'),
    ('Benjamin Anderson', '1996-08-05', 'benjamin.a@example.com', '666-777-8888', '444 Elm St'),
    ('Mia Walker', '1981-04-14', 'mia.w@example.com', '777-888-9999', '555 Oak Ave'),
    ('Ethan Wilson', '1990-01-15', 'ethan.w@example.com', '555-444-3333', '666 Pine Rd'),
    ('Isabella Turner', '1985-03-20', 'isabella.t@example.com', '111-222-3333', '777 Cedar Ln'),
    ('Henry Evans', '1995-07-10', 'henry.e@example.com', '333-444-5555', '888 Birch St'),
    ('Amelia Cox', '1980-09-05', 'amelia.c@example.com', '999-888-7777', '101 Cedar Ln'),
    ('Mason Stewart', '1992-12-02', 'mason.s@example.com', '222-111-0000', '222 Elm St'),
    ('Ella Murphy', '1998-04-30', 'ella.m@example.com', '666-777-8888', '333 Oak Ave'),
    ('Alexander Powell', '1987-06-15', 'alexander.p@example.com', '777-888-9999', '444 Pine Rd'),
    ('Grace Price', '1983-11-25', 'grace.p@example.com', '555-444-3333', '555 Cedar Ln'),
    ('Liam Wood', '1990-01-15', 'liam.w@example.com', '123-456-7890', '123 Main St'),
    ('Avery Foster', '1985-03-20', 'avery.f@example.com', '555-555-5555', '456 Elm St'),
    ('Evelyn Rogers', '1995-07-10', 'evelyn.r@example.com', '987-654-3210', '789 Oak Ave');


-- Insert 10 records into the Tickets table
INSERT INTO Tickets (Title, Departure, Arrival, Priority, DueDate, Duration, CustomerId)
VALUES
    ('Flight to Paris', 'New York', 'Paris', 'High', '2023-11-15', 8, 1),
    ('Business Meeting', 'Los Angeles', 'San Francisco', 'Medium', '2023-11-20', 2, 2),
    ('Conference Call', 'Chicago', 'Houston', 'Low', '2023-11-22', 1, 3),
    ('Train to Boston', 'New York', 'Boston', 'High', '2023-11-25', 4, 4),
    ('Client Meeting', 'San Francisco', 'Los Angeles', 'Medium', '2023-11-30', 3, 5),
    ('Project Deadline', 'Houston', 'Chicago', 'High', '2023-12-05', 6, 6),
    ('Vacation Trip', 'Boston', 'Miami', 'High', '2023-12-10', 10, 7),
    ('Team Building', 'Los Angeles', 'Las Vegas', 'Medium', '2023-12-15', 2, 8),
    ('Product Launch', 'Chicago', 'New York', 'High', '2023-12-20', 7, 9),
    ('Board Meeting', 'Houston', 'Dallas', 'Low', '2023-12-25', 2, 10);
