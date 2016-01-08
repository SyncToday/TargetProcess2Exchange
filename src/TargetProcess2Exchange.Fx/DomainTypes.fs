namespace TargetProcess2Exchange

module Domain =

    open FSharp.Data

    type UserStories = XmlProvider<"""<UserStories>
  <UserStory ResourceType="UserStory" Id="197" Name="Test Story 2">
    <Description nil="true" />
    <StartDate nil="true" />
    <EndDate nil="true" />
    <CreateDate>2016-01-08T13:28:36</CreateDate>
    <ModifyDate>2016-01-08T13:28:36</ModifyDate>
    <LastCommentDate nil="true" />
    <Tags></Tags>
    <NumericPriority>81.5</NumericPriority>
    <Effort>0.0000</Effort>
    <EffortCompleted>0.0000</EffortCompleted>
    <EffortToDo>0.0000</EffortToDo>
    <Progress>0.0000</Progress>
    <TimeSpent>0.0000</TimeSpent>
    <TimeRemain>0.0000</TimeRemain>
    <PlannedStartDate nil="true" />
    <PlannedEndDate nil="true" />
    <InitialEstimate>0.0000</InitialEstimate>
    <EntityType Id="4" Name="UserStory" />
    <Project ResourceType="Project" Id="192" Name="Test Project">
      <Process Id="3" Name="Scrum" />
    </Project>
    <Owner ResourceType="GeneralUser" Id="1">
      <FirstName>David</FirstName>
      <LastName>Podhola</LastName>
      <Login>admin</Login>
    </Owner>
    <LastCommentedUser nil="true" />
    <LinkedTestPlan nil="true" />
    <Release nil="true" />
    <Iteration nil="true" />
    <TeamIteration nil="true" />
    <Team ResourceType="Team" Id="191" Name="Test Team" />
    <Priority Id="5" Name="Nice To Have">
      <Importance>5</Importance>
    </Priority>
    <EntityState Id="73" Name="Open">
      <NumericPriority>73</NumericPriority>
    </EntityState>
    <ResponsibleTeam Id="2" />
    <Feature nil="true" />
    <CustomFields />
  </UserStory>
  <UserStory ResourceType="UserStory" Id="194" Name="Test">
    <Description>&lt;div&gt;Description&lt;/div&gt;
</Description>
    <StartDate>2016-01-07T00:00:00</StartDate>
    <EndDate nil="true" />
    <CreateDate>2016-01-08T13:07:51</CreateDate>
    <ModifyDate>2016-01-08T13:12:31</ModifyDate>
    <LastCommentDate nil="true" />
    <Tags>TestTag</Tags>
    <NumericPriority>81</NumericPriority>
    <Effort>8.0000</Effort>
    <EffortCompleted>8.0000</EffortCompleted>
    <EffortToDo>0.0000</EffortToDo>
    <Progress>1.0000</Progress>
    <TimeSpent>0.2500</TimeSpent>
    <TimeRemain>0.0000</TimeRemain>
    <PlannedStartDate>2016-01-03T00:00:00</PlannedStartDate>
    <PlannedEndDate>2016-01-09T23:59:59</PlannedEndDate>
    <InitialEstimate>0.0000</InitialEstimate>
    <EntityType Id="4" Name="UserStory" />
    <Project ResourceType="Project" Id="192" Name="Test Project">
      <Process Id="3" Name="Scrum" />
    </Project>
    <Owner ResourceType="GeneralUser" Id="1">
      <FirstName>David</FirstName>
      <LastName>Podhola</LastName>
      <Login>admin</Login>
    </Owner>
    <LastCommentedUser nil="true" />
    <LinkedTestPlan nil="true" />
    <Release ResourceType="Release" Id="195" Name="v1.0" />
    <Iteration nil="true" />
    <TeamIteration ResourceType="TeamIteration" Id="196" Name="Test Sprint 2015-01" />
    <Team ResourceType="Team" Id="191" Name="Test Team" />
    <Priority Id="5" Name="Nice To Have">
      <Importance>5</Importance>
    </Priority>
    <EntityState Id="73" Name="Open">
      <NumericPriority>73</NumericPriority>
    </EntityState>
    <ResponsibleTeam Id="1" />
    <Feature nil="true" />
    <CustomFields />
  </UserStory>
</UserStories>""">

    [<CLIMutable>]
    type Person = {
        FirstName:string
        LastName:string
    }

    type HelloMessage = 
       | Greet of Person
       | Hi
    
    // the "use-cases"
    type Hello = 
        Person -> string

    // the functions exported from the implementation
    // for the clients and servers to use.
    type API = {
        Hello : Hello
    }
