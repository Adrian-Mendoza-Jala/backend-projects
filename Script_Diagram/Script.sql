Project SkillMastery {
  database_type: 'SQLServer'
  Note: 'This schema is designed for the SkillMastery application, focus on user management, skill tracking, and progress monitoring'
}

Table Users {
  UserId integer [pk, increment]
  Name nvarchar(255) [not null]
  Email nvarchar(255) [not null, unique]
  Password varbinary(256) [not null] // Assuming passwords are securely hashed
  DateJoined datetime [not null, default: `getdate()`]

  CreatedAt datetime [not null, default: `getdate()`]
  UpdatedAt datetime [null] 
  CreatedBy integer [null, ref: - Users.UserId] 
  UpdatedBy integer [null, ref: - Users.UserId] 
}

Table Skills {
  SkillId integer [pk, increment]
  Name nvarchar(255) [not null]
  Description nvarchar(255) [null]
}

Table Goals {
  GoalId integer [pk, increment]
  UserId integer [not null, ref: > Users.UserId] 
  SkillId integer [not null, ref: > Skills.SkillId]
  Description nvarchar(255) [null]
  Deadline datetime [null]
  Status nvarchar(50) [not null]

  CreatedAt datetime [not null, default: `getdate()`]
  UpdatedAt datetime [null]
  CreatedBy integer [null, ref: - Users.UserId]
  UpdatedBy integer [null, ref: - Users.UserId]
}

Table Progress {
  ProgressId integer [pk, increment]
  UserId integer [not null, ref: > Users.UserId] 
  SkillId integer [not null, ref: > Skills.SkillId] 
  Milestones nvarchar(255) [null]
  Date datetime [not null, default: `getdate()`]

  CreatedAt datetime [not null, default: `getdate()`]
  UpdatedAt datetime [null]
  CreatedBy integer [null, ref: - Users.UserId]
  UpdatedBy integer [null, ref: - Users.UserId]
}
