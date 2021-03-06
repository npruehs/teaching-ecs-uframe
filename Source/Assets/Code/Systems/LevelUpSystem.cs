// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace ECSDemo {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using UniRx;
    using uFrame.Kernel;
    using ECSDemo;
    
    
    [uFrame.Attributes.uFrameIdentifier("331dbc77-558a-42af-b218-9b6cf89ce7ab")]
    public partial class LevelUpSystem : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<HealthComponent> _HealthComponentManager;
        
        private IEcsComponentManagerOf<LevelComponent> _LevelComponentManager;
        
        private IEcsComponentManagerOf<AttackComponent> _AttackComponentManager;
        
        private IEcsComponentManagerOf<TargetComponent> _TargetComponentManager;
        
        private IEcsComponentManagerOf<ArmorComponent> _ArmorComponentManager;
        
        private IEcsComponentManagerOf<AttackingEntity> _AttackingEntityManager;
        
        private IEcsComponentManagerOf<DefendingEntity> _DefendingEntityManager;
        
        private IEcsComponentManagerOf<LevelingEntity> _LevelingEntityManager;
        
        private LevelUpSystemExperienceChangedHandler LevelUpSystemExperienceChangedHandlerInstance = new LevelUpSystemExperienceChangedHandler();
        
        public IEcsComponentManagerOf<HealthComponent> HealthComponentManager {
            get {
                return _HealthComponentManager;
            }
            set {
                _HealthComponentManager = value;
            }
        }
        
        public IEcsComponentManagerOf<LevelComponent> LevelComponentManager {
            get {
                return _LevelComponentManager;
            }
            set {
                _LevelComponentManager = value;
            }
        }
        
        public IEcsComponentManagerOf<AttackComponent> AttackComponentManager {
            get {
                return _AttackComponentManager;
            }
            set {
                _AttackComponentManager = value;
            }
        }
        
        public IEcsComponentManagerOf<TargetComponent> TargetComponentManager {
            get {
                return _TargetComponentManager;
            }
            set {
                _TargetComponentManager = value;
            }
        }
        
        public IEcsComponentManagerOf<ArmorComponent> ArmorComponentManager {
            get {
                return _ArmorComponentManager;
            }
            set {
                _ArmorComponentManager = value;
            }
        }
        
        public IEcsComponentManagerOf<AttackingEntity> AttackingEntityManager {
            get {
                return _AttackingEntityManager;
            }
            set {
                _AttackingEntityManager = value;
            }
        }
        
        public IEcsComponentManagerOf<DefendingEntity> DefendingEntityManager {
            get {
                return _DefendingEntityManager;
            }
            set {
                _DefendingEntityManager = value;
            }
        }
        
        public IEcsComponentManagerOf<LevelingEntity> LevelingEntityManager {
            get {
                return _LevelingEntityManager;
            }
            set {
                _LevelingEntityManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            AttackingEntityManager = ComponentSystem.RegisterGroup<AttackingEntityGroup,AttackingEntity>();
            DefendingEntityManager = ComponentSystem.RegisterGroup<DefendingEntityGroup,DefendingEntity>();
            LevelingEntityManager = ComponentSystem.RegisterGroup<LevelingEntityGroup,LevelingEntity>();
            HealthComponentManager = ComponentSystem.RegisterComponent<HealthComponent>();
            LevelComponentManager = ComponentSystem.RegisterComponent<LevelComponent>();
            AttackComponentManager = ComponentSystem.RegisterComponent<AttackComponent>();
            TargetComponentManager = ComponentSystem.RegisterComponent<TargetComponent>();
            ArmorComponentManager = ComponentSystem.RegisterComponent<ArmorComponent>();
            this.OnEvent<ECSDemo.ExperienceChanged>().Subscribe(_=>{ LevelUpSystemExperienceChangedFilter(_); }).DisposeWith(this);
        }
        
        protected void LevelUpSystemExperienceChangedHandler(ECSDemo.ExperienceChanged data, LevelingEntity entity) {
            var handler = LevelUpSystemExperienceChangedHandlerInstance;
            handler.System = this;
            handler.Event = data;
            handler.Entity = entity;
            StartCoroutine(handler.Execute());
        }
        
        protected void LevelUpSystemExperienceChangedFilter(ECSDemo.ExperienceChanged data) {
            var EntityItem = LevelingEntityManager[data.Entity];
            if (EntityItem == null) {
                return;
            }
            if (!EntityItem.Enabled) {
                return;
            }
            this.LevelUpSystemExperienceChangedHandler(data, EntityItem);
        }
    }
}
