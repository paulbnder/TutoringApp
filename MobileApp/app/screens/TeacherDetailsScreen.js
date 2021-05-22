import React from 'react';
import { AntDesign } from '@expo/vector-icons';
import { StyleSheet, View } from 'react-native';
import { useTheme } from '@react-navigation/native';
import * as Haptics from 'expo-haptics';
import { Avatar } from 'react-native-elements';





function TeacherDetailsScreen({ navigation, route }) {
    const { margin, colors } = useTheme();
    const { teacher } = route.params;


    const goBack = () => {
        navigation.goBack();
        Haptics.selectionAsync();
      };

    const styles = StyleSheet.create({
        closeIcon: {
            zIndex: 10,
            top: margin,
            right: margin,
            opacity: 0.75,
            color: colors.text,
            position: 'absolute',
          },
        container: {
            top: 40,
            alignItems: 'center'
        }
    })

    return (
        <View >
            <AntDesign size={27} name="close" onPress={goBack} style={styles.closeIcon} />
            <View style={styles.container}>
                <Avatar
                    source={{
                        uri:teacher.profilePictureSource
                    }}
                    size = "xlarge"
                    rounded
                    >
                    <Avatar.Accessory size={40}/>
                </Avatar>
            </View>
        </View>
    );
}

export default TeacherDetailsScreen;