# com.rightback.ChocAn
RightBack group ChocAn class project
 Chocoholics Anonymous (ChocAn) is an organization dedicated to helping people addicted
to chocolate in all its glorious forms. Members pay a monthly fee to ChocAn. For this fee
they are entitled to unlimited consultations and treatments with health care professionals,
namely, dietitians, internists, and exercise experts. Every member is given a plastic card
embossed with the member’s name and a nine-digit member number and incorporating
a magnetic strip on which that information is encoded. Each health care professional
( provider ) who provides services to ChocAn members has a specially designed ChocAn
computer terminal, similar to a credit card device in a shop. When a provider’s terminal is
switched on, the provider is asked to enter his or her provider number.
 To receive health care services from ChocAn, the member hands his or her card to the
provider, who slides the card through the card reader on the terminal. The terminal then
dials the ChocAn Data Center, and the ChocAn Data Center computer verifi es the member
number. If the number is valid, the word Validated appears on the one-line display. If the
number is not valid, the reason is displayed, such as Invalid number or Member suspended;
the latter message indicates that fees are owed (that is, the member has not paid
membership fees for at least a month) and member status has been set to suspended.
 To bill ChocAn after a health care service has been provided to the member, the provider
again passes the card through the card reader or keys in the member number. When the word
Validated appears, the provider keys in the date the service was provided in the format
MM–DD–YYYY. The date of service is needed because hardware or other diffi culties may
have prevented the provider from billing ChocAn immediately after providing the service.
Next, the provider uses the Provider Directory to look up the appropriate six-digit service
code corresponding to the service provided. For example, 598470 is the code for a session
with a dietitian, whereas 883948 is the code for an aerobics exercise session. The provider
then keys in the service code. To check that the service code has been correctly looked up
and keyed in, the software product then displays the name of the service corresponding to
the code (up to 20 characters) and asks the provider to verify that this is indeed the service
that was provided. If the provider has entered a nonexistent code, an error message is
printed. The provider also can enter comments about the service provided.
 The software product now writes a record to disk that includes the following fi elds:
 Current date and time (MM–DD–YYYY HH:MM:SS).
 Date service was provided (MM–DD–YYYY).
 Provider number (9 digits).
 Member number (9 digits).
 Service code (6 digits).
 Comments (100 characters) (optional).
 The software product next looks up the fee to be paid for that service and displays it on
the provider’s terminal. For verifi cation purposes, the provider has a form on which to enter
the current date and time, the date the service was provided, member name and number,
service code, and fee to be paid. At the end of the week, the provider totals the fees to verify
the amount to be paid to that provider by ChocAn for that week.
 At any time, a provider can request the software product for a Provider Directory, an
alphabetically ordered list of service names and corresponding service codes and fees. The
Provider Directory is sent to the provider as an e-mail attachment.
 At midnight on Friday, the main accounting procedure is run at the ChocAn Data Center.
It reads the week’s fi le of services provided and prints a number of reports. Each report also
can be run individually at the request of a ChocAn manager at any time during the week.
 Each member who has consulted a ChocAn provider during that week receives a list of
services provided to that member, sorted in order of service date. The report, which is also 
sent as an e-mail attachment, includes:
 Member name (25 characters).
 Member number (9 digits).
 Member street address (25 characters).
 Member city (14 characters).
 Member state (2 letters).
 Member ZIP code (5 digits).
 For each service provided, the following details are required:
 Date of service (MM–DD–YYYY).
 Provider name (25 characters).
 Service name (20 characters).
 Each provider who has billed ChocAn during that week receives a report, sent as an
e-mail attachment, containing the list of services he or she provided to ChocAn members.
To simplify the task of verifi cation, the report contains the same information as that entered
on the provider’s form, in the order that the data were received by the computer. At the end
of the report is a summary including the number of consultations with members and the
total fee for that week. That is, the fi elds of the report include:
 Provider name (25 characters).
 Provider number (9 digits).
 Provider street address (25 characters).
 Provider city (14 characters).
 Provider state (2 letters).
 Provider ZIP code (5 digits).
 For each service provided, the following details are required:
 Date of service (MM–DD–YYYY).
 Date and time data were received by the computer (MM–DD–YYYY HH:MM:SS).
 Member name (25 characters).
 Member number (9 digits).
 Service code (6 digits).
 Fee to be paid (up to $999.99).
 Total number of consultations with members (3 digits).
 Total fee for week (up to $99,999.99).
 A record consisting of electronic funds transfer (EFT) data is then written to a disk;
banking computers will later ensure that each provider’s bank account is credited with the
appropriate amount.
 A summary report is given to the manager for accounts payable. The report lists every
provider to be paid that week, the number of consultations each had, and his or her total
fee for that week. Finally, the total number of providers who provided services, the total
number of consultations, and the overall fee total are printed.
 During the day, the software at the ChocAn Data Center is run in interactive mode to
allow operators to add new members to ChocAn, to delete members who have resigned, and
to update member records. Similarly, provider records are added, deleted, and updated.
 The processing of payments of ChocAn membership fees has been contracted out to
Acme Accounting Services, a third-party organization. Acme is responsible for fi nancial
procedures such as recording payments of membership fees, suspending members whose
fees are overdue, and reinstating suspended members who have now paid what is owing.
The Acme computer updates the relevant ChocAn Data Center computer membership
records each evening at 9 P.M.
 Your organization has been awarded the contract to write only the ChocAn data processing
software; another organization will be responsible for the communications software,
for designing the ChocAn provider’s terminal, for the software needed by Acme Accounting
Services, and for implementing the EFT component. The contract states that, at the
acceptance test, the data from a provider’s terminal must be simulated by keyboard input
and data to be transmitted to a provider’s terminal display must appear on the screen. A
manager’s terminal must be simulated by the same keyboard and screen. Each member
report must be written to its own fi le; the name of the fi le should begin with the member
name, followed by the date of the report. The provider reports should be handled the same
way. The Provider Directory must also be created as a fi le. None of the fi les should actually
be sent as e-mail attachments. As for the EFT data, all that is required is that a fi le be set up
containing the provider name, provider number, and the amount to be transferred. 
