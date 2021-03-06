﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class fees_and_facilitiesContext : DbContext
    {
        public virtual DbSet<AccountInformationParameter> AccountInformationParameter { get; set; }
        public virtual DbSet<AccountInformationParameterTranslation> AccountInformationParameterTranslation { get; set; }
        public virtual DbSet<AccountParameterValues> AccountParameterValues { get; set; }
        public virtual DbSet<AccountParameterValuesTranslation> AccountParameterValuesTranslation { get; set; }
        public virtual DbSet<BankCurrencyTable> BankCurrencyTable { get; set; }
        public virtual DbSet<DormitoriesTable> DormitoriesTable { get; set; }
        public virtual DbSet<DormitoriesTableTranslation> DormitoriesTableTranslation { get; set; }
        public virtual DbSet<DormitoryBankAccountTable> DormitoryBankAccountTable { get; set; }
        public virtual DbSet<DormitoryInformationTable> DormitoryInformationTable { get; set; }
        public virtual DbSet<DormitoryInformationTableTranslation> DormitoryInformationTableTranslation { get; set; }
        public virtual DbSet<DormitoryType> DormitoryType { get; set; }
        public virtual DbSet<DormitoryTypeTranslation> DormitoryTypeTranslation { get; set; }
        public virtual DbSet<FacilityOption> FacilityOption { get; set; }
        public virtual DbSet<FacilityOptionTranslation> FacilityOptionTranslation { get; set; }
        public virtual DbSet<FacilityTable> FacilityTable { get; set; }
        public virtual DbSet<FacilityTableTranslation> FacilityTableTranslation { get; set; }
        public virtual DbSet<LanguageTable> LanguageTable { get; set; }
        public virtual DbSet<RoomFacility> RoomFacility { get; set; }
        public virtual DbSet<RoomTable> RoomTable { get; set; }
        public virtual DbSet<RoomTableTranslation> RoomTableTranslation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DARK-SHILLA\SQLEXPRESS;Database=fees_and_facilities;Trusted_Connection=True;");
            }
        }

        //  public fees_and_facilitiesContext(DbContextOptions<fees_and_facilitiesContext> options) : base(options) {

        //  }

        //public fees_and_facilitiesContext() : base()
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<fees_and_facilitiesContext>();
        //    optionsBuilder.UseSqlServer(@"Server=DARK-SHILLA\SQLEXPRESS;Database=fees_and_facilities;Trusted_Connection=True;");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountInformationParameter>(entity =>
            {
                entity.ToTable("account_information_parameter");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<AccountInformationParameterTranslation>(entity =>
            {
                entity.HasKey(e => new { e.AccountInfoNonTransId, e.LanguageId });

                entity.ToTable("account_information_parameter_translation");

                entity.Property(e => e.AccountInfoNonTransId).HasColumnName("account_info_non_trans_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Parameter)
                    .IsRequired()
                    .HasColumnName("parameter")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountInfoNonTrans)
                    .WithMany(p => p.AccountInformationParameterTranslation)
                    .HasForeignKey(d => d.AccountInfoNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_information_parameter_translation_fk0");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.AccountInformationParameterTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_information_parameter_translation_fk1");
            });

            modelBuilder.Entity<AccountParameterValues>(entity =>
            {
                entity.ToTable("account_parameter_values");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.ParameterId).HasColumnName("parameter_id");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.AccountParameterValues)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_parameter_values_fk0");

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.AccountParameterValues)
                    .HasForeignKey(d => d.ParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_parameter_values_fk1");
            });

            modelBuilder.Entity<AccountParameterValuesTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.AccountParamsValuesNonTransId });

                entity.ToTable("account_parameter_values_translation");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.AccountParamsValuesNonTransId).HasColumnName("account_params_values_non_trans_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountParamsValuesNonTrans)
                    .WithMany(p => p.AccountParameterValuesTranslation)
                    .HasForeignKey(d => d.AccountParamsValuesNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_parameter_values_translation_fk1");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.AccountParameterValuesTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_parameter_values_translation_fk0");
            });

            modelBuilder.Entity<BankCurrencyTable>(entity =>
            {
                entity.ToTable("bank_currency_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankId).HasColumnName("bank_id");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasColumnName("currency_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.BankCurrencyTable)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bank_currency_table_fk0");
            });

            modelBuilder.Entity<DormitoriesTable>(entity =>
            {
                entity.ToTable("dormitories_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DormitoryTypeId).HasColumnName("dormitory_type_id");

                entity.Property(e => e.RoomPriceCurrency)
                    .IsRequired()
                    .HasColumnName("room_price_currency")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoomPriceCurrencySymbol)
                    .IsRequired()
                    .HasColumnName("room_price_currency_symbol")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.DormitoryType)
                    .WithMany(p => p.DormitoriesTable)
                    .HasForeignKey(d => d.DormitoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dormitories_table_fk0");
            });

            modelBuilder.Entity<DormitoriesTableTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.DormitoriesTableNonTransId });

                entity.ToTable("dormitories_table_translation");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.DormitoriesTableNonTransId).HasColumnName("dormitories_table_non_trans_id");

                entity.Property(e => e.DormitoryAddress)
                    .IsRequired()
                    .HasColumnName("dormitory_address")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DormitoryName)
                    .IsRequired()
                    .HasColumnName("dormitory_name")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.GenderAllocation)
                    .IsRequired()
                    .HasColumnName("gender_allocation")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoomsPaymentPeriod)
                    .IsRequired()
                    .HasColumnName("rooms_payment_period")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.DormitoriesTableNonTrans)
                    .WithMany(p => p.DormitoriesTableTranslation)
                    .HasForeignKey(d => d.DormitoriesTableNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dormitories_table_translation_fk1");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.DormitoriesTableTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dormitories_table_translation_fk0");
            });

            modelBuilder.Entity<DormitoryBankAccountTable>(entity =>
            {
                entity.ToTable("dormitory_bank_account_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("bank_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DormitoryId).HasColumnName("dormitory_id");

                entity.HasOne(d => d.Dormitory)
                    .WithMany(p => p.DormitoryBankAccountTable)
                    .HasForeignKey(d => d.DormitoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dormitory_bank_account_table_fk0");
            });

            modelBuilder.Entity<DormitoryInformationTable>(entity =>
            {
                entity.ToTable("dormitory_information_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DormitoryTypeId).HasColumnName("dormitory_type_id");

                entity.HasOne(d => d.DormitoryType)
                    .WithMany(p => p.DormitoryInformationTable)
                    .HasForeignKey(d => d.DormitoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dormitory_information_table_fk0");
            });

            modelBuilder.Entity<DormitoryInformationTableTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.DormitoryInfoNonTransId });

                entity.ToTable("dormitory_information_table_translation");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("language_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DormitoryInfoNonTransId).HasColumnName("dormitory_info_non_trans_id");

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasColumnName("information")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.DormitoryInfoNonTrans)
                    .WithMany(p => p.DormitoryInformationTableTranslation)
                    .HasForeignKey(d => d.DormitoryInfoNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dormitory_information_table_translation_fk1");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.DormitoryInformationTableTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dormitory_information_table_translation_fk0");
            });

            modelBuilder.Entity<DormitoryType>(entity =>
            {
                entity.ToTable("dormitory_type");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<DormitoryTypeTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.DormitoryTypeNonTransId });

                entity.ToTable("dormitory_type_translation");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.DormitoryTypeNonTransId).HasColumnName("dormitory_type_non_trans_id");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("type_name")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.DormitoryTypeNonTrans)
                    .WithMany(p => p.DormitoryTypeTranslation)
                    .HasForeignKey(d => d.DormitoryTypeNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dormitory_type_translation_fk1");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.DormitoryTypeTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dormitory_type_translation_fk0");
            });

            modelBuilder.Entity<FacilityOption>(entity =>
            {
                entity.ToTable("facility_option");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FacilityId).HasColumnName("facility_id");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.FacilityOption)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("facility_option_fk0");
            });

            modelBuilder.Entity<FacilityOptionTranslation>(entity =>
            {
                entity.HasKey(e => new { e.FacilityOptionNonTransId, e.LanguageId });

                entity.ToTable("facility_option_translation");

                entity.Property(e => e.FacilityOptionNonTransId).HasColumnName("facility_option_non_trans_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.FacilityOption)
                    .IsRequired()
                    .HasColumnName("facility_option")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityOptionDescription)
                    .IsRequired()
                    .HasColumnName("facility_option_description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.FacilityOptionNonTrans)
                    .WithMany(p => p.FacilityOptionTranslation)
                    .HasForeignKey(d => d.FacilityOptionNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("facility_option_translation_fk0");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.FacilityOptionTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("facility_option_translation_fk1");
            });

            modelBuilder.Entity<FacilityTable>(entity =>
            {
                entity.ToTable("facility_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FacilityIconUrl)
                    .IsRequired()
                    .HasColumnName("facility_icon_url")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacilityTableTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.FacilityTableNonTransId });

                entity.ToTable("facility_table_translation");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.FacilityTableNonTransId).HasColumnName("facility_table_non_trans_id");

                entity.Property(e => e.FacilityDescription)
                    .IsRequired()
                    .HasColumnName("facility_description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityTitle)
                    .IsRequired()
                    .HasColumnName("facility_title")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.FacilityTableNonTrans)
                    .WithMany(p => p.FacilityTableTranslation)
                    .HasForeignKey(d => d.FacilityTableNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("facility_table_translation_fk1");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.FacilityTableTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("facility_table_translation_fk0");
            });

            modelBuilder.Entity<LanguageTable>(entity =>
            {
                entity.ToTable("language_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasColumnName("language_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomFacility>(entity =>
            {
                entity.ToTable("room_facility");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FacilityId).HasColumnName("facility_id");

                entity.Property(e => e.FacilityOptionId).HasColumnName("facility_option_id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.RoomFacility)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_facility_fk0");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomFacility)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_facility_fk1");
            });

            modelBuilder.Entity<RoomTable>(entity =>
            {
                entity.ToTable("room_table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DormitoryId).HasColumnName("dormitory_id");

                entity.Property(e => e.RoomArea).HasColumnName("room_area");

                entity.Property(e => e.RoomPictureUrl)
                    .IsRequired()
                    .HasColumnName("room_picture_url")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoomPrice).HasColumnName("room_price");

                entity.Property(e => e.RoomPriceInstallment).HasColumnName("room_price_installment");

                entity.HasOne(d => d.Dormitory)
                    .WithMany(p => p.RoomTable)
                    .HasForeignKey(d => d.DormitoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_table_fk0");
            });

            modelBuilder.Entity<RoomTableTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.RoomTableNonTransId });

                entity.ToTable("room_table_translation");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.RoomTableNonTransId).HasColumnName("room_table_non_trans_id");

                entity.Property(e => e.RoomTitle)
                    .IsRequired()
                    .HasColumnName("room_title")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasColumnName("room_type")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.RoomTableTranslation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_table_translation_fk0");

                entity.HasOne(d => d.RoomTableNonTrans)
                    .WithMany(p => p.RoomTableTranslation)
                    .HasForeignKey(d => d.RoomTableNonTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_table_translation_fk1");
            });
        }
    }
}
