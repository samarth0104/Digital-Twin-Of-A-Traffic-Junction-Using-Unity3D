import random
import csv
import time


# Function to read the number from a file
def read_number_from_file(filename):
    try:
        with open(filename, "r") as file:
            number = int(file.read())
    except FileNotFoundError:
        # If the file doesn't exist, return a default number (e.g., 3)
        return 3
    except ValueError:
        # If the file is empty or contains invalid data, return a default number (e.g., 3)
        return 3
    return number


# Function to write a number to a file
def write_number_to_file(filename, number):
    with open(filename, "w") as file:
        file.write(str(number))


# Function to sort lanes based on car numbers and write to CSV
def sort_lanes_and_write_to_csv(filenames, numbers):
    lanes = [
        (filename.split(".")[0], number) for filename, number in zip(filenames, numbers)
    ]
    sorted_lanes = sorted(lanes, key=lambda x: x[1], reverse=True)
    with open(
        "C:\\Users\\samar\\OneDrive\\Desktop\\PESU\\Last\\DTX\\Cap_2\\Assets\\lane.csv",
        "w",
        newline="",
    ) as file:
        writer = csv.writer(file)
        writer.writerow(["Lane", "Number of Cars"])
        writer.writerows(sorted_lanes)


# Main function
def main():
    # List of filenames for spawn count files
    filenames = [
        "C:\\Users\\samar\\OneDrive\\Desktop\\PESU\\Last\\DTX\\Cap_2\\Assets\\spawn_count1.txt",
        "C:\\Users\\samar\\OneDrive\\Desktop\\PESU\\Last\\DTX\\Cap_2\\Assets\\spawn_count2.txt",
        "C:\\Users\\samar\\OneDrive\\Desktop\\PESU\\Last\\DTX\\Cap_2\\Assets\\spawn_count3.txt",
        "C:\\Users\\samar\\OneDrive\\Desktop\\PESU\\Last\\DTX\\Cap_2\\Assets\\spawn_count4.txt",
    ]

    try:
        while True:
            # Update numbers for all files
            numbers = []
            total_time = 0
            for filename in filenames:
                number = random.randint(
                    3, 18
                )  # Generate a random number between 3 and 20
                write_number_to_file(filename, number)
                numbers.append(number)
                print("Number for", filename, "updated to:", number)
                # Calculate total time based on spawn count
                if number < 5:
                    total_time += 10
                elif 5 <= number <= 10:
                    total_time += 15
                else:
                    total_time += 20

            # Sort lanes and write to CSV
            sort_lanes_and_write_to_csv(filenames, numbers)

            # Write total time to totaltime.txt
            write_number_to_file(
                "C:\\Users\\samar\\OneDrive\\Desktop\\PESU\\Last\\DTX\\Cap_2\\Assets\\totaltime.txt",
                total_time,
            )

            # Wait for the total time before updating again
            time.sleep(total_time)

    except KeyboardInterrupt:
        print("\nTerminating...")


# Execute the main function when the script is run
if __name__ == "__main__":
    main()
