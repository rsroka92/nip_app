using Microsoft.EntityFrameworkCore;
using NIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Subject> subject { get; set; }
        public DbSet<Representative> representative { get; set; }
        public DbSet<AccountNumber> accountNumber { get; set; }
        public DbSet<Partner> partner { get; set; }
    }
}
/*
 * create table subject (
	nip varchar(10) NOT NULL,
	name varchar(255),
        statusVat varchar(20),
        regon varchar(9),
        pesel varchar(11),
        krs varchar(10),
        residenceAddress varchar(255),
        workingAddress varchar(255),
        registrationLegalDate date,
        registrationDenialBasis varchar(255),
        registrationDenialDate date,
        restorationBasis varchar(255),
        restorationDate date,
        removalBasis varchar(255),
        removalDate date,
        hasVirtualAccounts bit,
        requestId varchar(255),
        requestDateTime date,
        PRIMARY KEY (nip)
)

create table representative (
	id serial,
	firstName varchar(255),
        lastName varchar(255),
        subjectnip varchar(10),
        companyName varchar(255),
        PRIMARY KEY (id),
        CONSTRAINT fk_nip
		FOREIGN KEY(subjectnip) 
		REFERENCES subject(nip)
)

    create table accountNumber (
	id serial,
	accountNumber varchar(255),
        subjectnip varchar(10),
        PRIMARY KEY (id),
        CONSTRAINT fk_nip
		FOREIGN KEY(subjectnip) 
		REFERENCES subject(nip)
)

    create table partner (
	id serial,
        companyName varchar(255),
        firstName varchar(255),
        lastName varchar(255),
        subjectnip varchar(10),
        pesel varchar(255),
        nip varchar(10),
        PRIMARY KEY (id),
        CONSTRAINT fk_nip
		FOREIGN KEY(subjectnip) 
		REFERENCES subject(nip)
)
*/
