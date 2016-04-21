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
    
    
    [uFrame.Attributes.uFrameIdentifier("644c254a-b5f5-4d50-8d00-8479a65a9cb5")]
    public partial class DamageSystem : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<HealthComponent> _HealthComponentManager;
        
        private IEcsComponentManagerOf<AttackComponent> _AttackComponentManager;
        
        private IEcsComponentManagerOf<TargetComponent> _TargetComponentManager;
        
        private IEcsComponentManagerOf<ArmorComponent> _ArmorComponentManager;
        
        private IEcsComponentManagerOf<AttackingEntity> _AttackingEntityManager;
        
        private IEcsComponentManagerOf<DefendingEntity> _DefendingEntityManager;
        
        private DamageSystemEntityAttackedHandler DamageSystemEntityAttackedHandlerInstance = new DamageSystemEntityAttackedHandler();
        
        public IEcsComponentManagerOf<HealthComponent> HealthComponentManager {
            get {
                return _HealthComponentManager;
            }
            set {
                _HealthComponentManager = value;
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
        
        public override void Setup() {
            base.Setup();
            AttackingEntityManager = ComponentSystem.RegisterGroup<AttackingEntityGroup,AttackingEntity>();
            DefendingEntityManager = ComponentSystem.RegisterGroup<DefendingEntityGroup,DefendingEntity>();
            HealthComponentManager = ComponentSystem.RegisterComponent<HealthComponent>();
            AttackComponentManager = ComponentSystem.RegisterComponent<AttackComponent>();
            TargetComponentManager = ComponentSystem.RegisterComponent<TargetComponent>();
            ArmorComponentManager = ComponentSystem.RegisterComponent<ArmorComponent>();
            this.OnEvent<ECSDemo.EntityAttacked>().Subscribe(_=>{ DamageSystemEntityAttackedFilter(_); }).DisposeWith(this);
        }
        
        protected void DamageSystemEntityAttackedHandler(ECSDemo.EntityAttacked data, AttackingEntity attacker, DefendingEntity defender) {
            var handler = DamageSystemEntityAttackedHandlerInstance;
            handler.System = this;
            handler.Event = data;
            handler.Attacker = attacker;
            handler.Defender = defender;
            StartCoroutine(handler.Execute());
        }
        
        protected void DamageSystemEntityAttackedFilter(ECSDemo.EntityAttacked data) {
            var AttackerItem = AttackingEntityManager[data.Attacker];
            if (AttackerItem == null) {
                return;
            }
            if (!AttackerItem.Enabled) {
                return;
            }
            var DefenderItem = DefendingEntityManager[data.Defender];
            if (DefenderItem == null) {
                return;
            }
            if (!DefenderItem.Enabled) {
                return;
            }
            this.DamageSystemEntityAttackedHandler(data, AttackerItem, DefenderItem);
        }
    }
}
